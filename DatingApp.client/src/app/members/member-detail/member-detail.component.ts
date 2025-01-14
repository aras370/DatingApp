import { Component, OnInit } from '@angular/core';
import { MemberDTO } from '../../UserDTO/MemberDTO';
import { MemberService } from '../../services/member.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrl: './member-detail.component.css',
})
export class MemberDetailComponent implements OnInit {
  constructor(
    private membersevice: MemberService,
    private route: ActivatedRoute
  ) { }

  member: MemberDTO;

  galleryoption: NgxGalleryOptions[];

  galleryImages: NgxGalleryImage[];

  ngOnInit(): void {
    this.loadmember()
    this.galleryoption = [{
      width: '500px',
      height: '500px',
      imagePercent: 100,
      thumbnailsColumns: 4,
      imageAnimation: NgxGalleryAnimation.Slide,
      preview: false
    }]
  }


  getimages() {

    var imageUrls = []

    for (var photo of this.member.PhotoDTOs)
      imageUrls.push({
        small: photo?.url,
        medium: photo?.url,
        big: photo?.url
      })
      return imageUrls;
  }


  loadmember() {
    this.membersevice
      .getmember(this.route.snapshot.paramMap.get('username'))
      .subscribe((member) => {
        this.member = member;
        this.galleryImages=this.getimages()
      });
  }
}
